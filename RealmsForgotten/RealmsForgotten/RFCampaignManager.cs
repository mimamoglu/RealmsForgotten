// Decompiled with JetBrains decompiler
// Type: RealmsForgotten.RFCampaignManager
// Assembly: RealmsForgotten, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B26E324A-F09C-4542-BFFC-02D91686071A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\RF_Core\bin\Win64_Shipping_Client\RealmsForgotten.dll

using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.SaveSystem.Load;

namespace RealmsForgotten
{
  public class RFCampaignManager : MBGameManager
  {
    private bool _loadingSavedGame;
    private LoadResult _loadedGameResult;
    private int _seed = 1234;

    public RFCampaignManager()
    {
      this._loadingSavedGame = false;
      this._seed = (int) DateTime.Now.Ticks & (int) ushort.MaxValue;
    }

    public override void OnGameEnd(Game game)
    {
      MBDebug.SetErrorReportScene((Scene) null);
      base.OnGameEnd(game);
    }

    protected override void DoLoadingForGameManager(
      GameManagerLoadingSteps gameManagerLoadingStep,
      out GameManagerLoadingSteps nextStep)
    {
      nextStep = GameManagerLoadingSteps.None;
      switch (gameManagerLoadingStep)
      {
        case GameManagerLoadingSteps.PreInitializeZerothStep:
          nextStep = GameManagerLoadingSteps.FirstInitializeFirstStep;
          break;
        case GameManagerLoadingSteps.FirstInitializeFirstStep:
          MBGameManager.LoadModuleData(this._loadingSavedGame);
          nextStep = GameManagerLoadingSteps.WaitSecondStep;
          break;
        case GameManagerLoadingSteps.WaitSecondStep:
          if (!this._loadingSavedGame)
            MBGameManager.StartNewGame();
          nextStep = GameManagerLoadingSteps.SecondInitializeThirdState;
          break;
        case GameManagerLoadingSteps.SecondInitializeThirdState:
          MBGlobals.InitializeReferences();
          if (!this._loadingSavedGame)
          {
            MBDebug.Print("Initializing new game begin...");
            Campaign campaign = new Campaign(CampaignGameMode.Campaign);
            Game.CreateGame((TaleWorlds.Core.GameType) campaign, (GameManagerBase) this);
            campaign.SetLoadingParameters(Campaign.GameLoadingType.NewCampaign);
            MBDebug.Print("Initializing new game end...");
          }
          else
          {
            MBDebug.Print("Initializing saved game begin...");
            ((Campaign) Game.LoadSaveGame(this._loadedGameResult, (GameManagerBase) this).GameType).SetLoadingParameters(Campaign.GameLoadingType.SavedCampaign);
            this._loadedGameResult = (LoadResult) null;
            Common.MemoryCleanupGC();
            MBDebug.Print("Initializing saved game end...");
          }
          Game.Current.DoLoading();
          nextStep = GameManagerLoadingSteps.PostInitializeFourthState;
          break;
        case GameManagerLoadingSteps.PostInitializeFourthState:
          bool flag = true;
          foreach (MBSubModuleBase subModule in Module.CurrentModule.SubModules)
            flag = flag && subModule.DoLoading(Game.Current);
          nextStep = flag ? GameManagerLoadingSteps.FinishLoadingFifthStep : GameManagerLoadingSteps.PostInitializeFourthState;
          break;
        case GameManagerLoadingSteps.FinishLoadingFifthStep:
          nextStep = Game.Current.DoLoading() ? GameManagerLoadingSteps.None : GameManagerLoadingSteps.FinishLoadingFifthStep;
          break;
      }
    }

    public override void OnLoadFinished()
    {
      if (!this._loadingSavedGame)
      {
        MBDebug.Print("Switching to menu window...");
        this.LaunchSandboxCharacterCreation();
      }
      else
      {
        if (CampaignSiegeTestStatic.IsSiegeTestBuild)
          CampaignSiegeTestStatic.DisableSiegeTest();
        Game.Current.GameStateManager.OnSavedGameLoadFinished();
        Game.Current.GameStateManager.CleanAndPushState((TaleWorlds.Core.GameState) Game.Current.GameStateManager.CreateState<MapState>());
        string name = Game.Current.GameStateManager.ActiveState is MapState activeState ? activeState.GameMenuId : (string) null;
        if (!string.IsNullOrEmpty(name))
        {
          PlayerEncounter.Current?.OnLoad();
          Campaign.Current.GameMenuManager.SetNextMenu(name);
        }
        PartyBase.MainParty.Visuals?.SetMapIconAsDirty();
        Campaign.Current.CampaignInformationManager.OnGameLoaded();
        foreach (Settlement settlement in Settlement.All)
          settlement.Party.Visuals.RefreshLevelMask(settlement.Party);
        CampaignEventDispatcher.Instance.OnGameLoadFinished();
        
      }
      this.IsLoaded = true;
    }

    private void LaunchSandboxCharacterCreation() => Game.Current.GameStateManager.CleanAndPushState((TaleWorlds.Core.GameState) Game.Current.GameStateManager.CreateState<CharacterCreationState>((object) new RFCharacterCreationContent()));
  }
}
