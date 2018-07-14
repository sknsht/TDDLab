namespace TDDLab.Core.Infrastructure {
    public interface IWorker : IStartable {
        void DoJob();
    }
}