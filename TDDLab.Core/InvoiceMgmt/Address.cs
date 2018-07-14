using System.Reflection;
using BasicUtils;

namespace TDDLab.Core.InvoiceMgmt {
    public class Address : ValidatedDomainObject, IValidatedObject {
        public Address(string addresLine, string city, string state, string zip) {
            AddressLine = addresLine;
            City = city;
            State = state;
            Zip = zip;
        }

        public string AddressLine { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Zip { get; private set; }

        public sealed class ValidationRules {
            public static IBusinessRule<Address> AddressLine1 {
                get {
                    return new BusinessRule<Address>(MethodBase.GetCurrentMethod().Name, "AddressLine should be specified", address => address.AddressLine.IsNotEmpty());
                }
            }

            public static IBusinessRule<Address> City {
                get {
                    return new BusinessRule<Address>(MethodBase.GetCurrentMethod().Name, "City should be specified", address => address.City.IsNotEmpty());
                }
            }

            public static IBusinessRule<Address> Zip {
                get {
                    return new BusinessRule<Address>(MethodBase.GetCurrentMethod().Name, "Zip code should be specified", address => address.Zip.IsNotEmpty());
                }
            }

            public static IBusinessRule<Address> State {
                get {
                    return new BusinessRule<Address>(MethodBase.GetCurrentMethod().Name, "State should be properly specified", address => address.State.IsNotEmpty());
                }
            }
        }
        protected override IBusinessRuleSet Rules {
            get {
                return new BusinessRuleSet<Address>(
                    ValidationRules.AddressLine1,
                    ValidationRules.City,
                    ValidationRules.Zip,
                    ValidationRules.State);
            }
        }
    }
}