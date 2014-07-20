using System.Security.Principal;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using KeepFit.Core.Models;

namespace KeepFit.Web.Identity
{
    public class KeepFitPrincipal : IPrincipal, IXmlSerializable
    {
        private KeepFitIdentity _identity;

        public IIdentity Identity
        {
            get
            {
                return _identity;
            }
        }

        public KeepFitPrincipal()
        {
            _identity = new KeepFitIdentity();
        }

        public KeepFitPrincipal(int userId, int individualId, string userName, string firstName, string lastName, RoleType roleType, string token, bool isPasswordExpired = false, bool rememberMe = false)
        {
            _identity = new KeepFitIdentity(userId, individualId, userName, firstName, lastName, roleType, token, 0, isPasswordExpired, rememberMe);
        }

        public bool IsInRole(string role)
        {
            return _identity.RoleType.ToString() == role;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadToDescendant("Identity");

            _identity = new KeepFitIdentity();
            _identity.ReadXml(reader);

            reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Identity");

            _identity.WriteXml(writer);

            writer.WriteEndElement();
        }
    }
}