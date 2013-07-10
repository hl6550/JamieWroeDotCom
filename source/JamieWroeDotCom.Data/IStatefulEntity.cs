using System.Data;

namespace JamieWroeDotCom.Data
{
    public interface IStatefulEntity<out T>
    {
        T Entity { get; }

        EntityState State { get; set; }
    }
}