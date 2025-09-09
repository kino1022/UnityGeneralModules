using System;
using GeneralModule.Spawner.Data.Interface;
using VContainer.Unity;

namespace GeneralModule.Spawner.Pattern.Interface {
    
    public interface ISpawnPattern : IStartable,IDisposable {

        public Action<ISpawnerData> OnSpawnTiming { get; set; }
        
    }
}

