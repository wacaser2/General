using System.IO;
namespace General {
	public interface ILoadable<T> {
		T Load(BinaryReader br);
	}
}