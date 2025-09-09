using GeneralModule.Spawner.Data.Interface;

namespace GeneralModule.Spawner.Interface {
    public interface ISpawnExecutor {

        void Spawn(ISpawnerData data);
        
    }
}