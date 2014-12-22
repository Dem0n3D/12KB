using System.Collections.Generic;
using System.ServiceModel;

namespace SnakeServer {
	[ServiceContract]
	public interface ISnakeServer {
		[OperationContract]
		void DoWork();

		[OperationContract]
		void Start(ref Snake snake, ref Field field, int height, int widht);

		[OperationContract]
		void Motion(ref Snake snake, ref Field field);

		[OperationContract]
		void AddBonus(ref Snake snake, ref Field field);
	}
}