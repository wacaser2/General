using System.IO;
namespace General {
	public interface ISendable {
		void ToSend(BinaryWriter bw);
	}
}