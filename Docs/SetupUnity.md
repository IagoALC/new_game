# Setup no Unity

1) Abrir o projeto em `/var/www/html/new_game` pelo Unity Hub.
2) Criar cenas reais:
   - `Assets/Scenes/Bootstrap.unity`: adicionar GameObject com `Bootstrap`, `ProfileStorage`, `EconomyWallet`, `EnergySystem`, refs de config.
   - `Assets/Scenes/Hub.unity`: UI de energia/moedas, botões para Puzzle/Upgrades/Loja/Eventos/Missões, `HudController` referenciando wallet/energy.
   - `Assets/Scenes/Puzzle.unity`: tabuleiro e HUD de partida; ligar `PuzzleGameController` a `EnergySystem`, `EconomyWallet`, `LevelConfig`.
3) ScriptableObjects:
   - `Assets/ScriptableObjects/EconomyConfig.asset`: definir `maxEnergy`, `energyRechargeMinutes`, `baseCoinsReward`.
   - `Assets/ScriptableObjects/Levels/LevelConfig_001.asset` etc. Ajustar tempo/movimentos/recompensa.
   - `Assets/ScriptableObjects/LevelCatalog.asset`: incluir lista de `LevelConfig`.
4) Referências:
   - Em `EnergySystem`, setar `EconomyConfig` e `currentEnergy` inicial no Inspector.
   - Em `PuzzleGameController`, setar `LevelConfig` e custo de energia.
   - Em `ProfileStorage`, setar refs de `EconomyWallet` e `EnergySystem` da cena Bootstrap.
5) Navegação:
   - Na UI do Hub, chamar `SceneLoader.LoadPuzzle()` ao tocar Jogar.
   - No fim do puzzle, chamar `SceneLoader.LoadHub()`.
6) Ads/Analytics/Remote Config:
   - Trocar stubs em `AdService`, `AnalyticsService`, `RemoteConfigService` pelos SDKs (AdMob/LevelPlay, Unity/Firebase Analytics, Firebase Remote Config). Manter nomes de métodos para minimizar refactor.
