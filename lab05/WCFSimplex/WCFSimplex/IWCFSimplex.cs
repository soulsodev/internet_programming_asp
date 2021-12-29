using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFSimplex
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWCFSimplex
    {
        [OperationContract]
        int Add(int x, int y);

        [OperationContract]
        String Concat(string s, double d);

        [OperationContract]
        A Sum(A a1, A a2);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WCFSimplex.ContractType".
    [DataContract]
    public class A
    {
        [DataMember]
        public string s;
        [DataMember]
        public int k;
        [DataMember]
        public float f;

        public A() { }

        public A(string s, int k, float f)
        {
            this.s = s;
            this.k = k;
            this.f = f;
        }
    }
}
