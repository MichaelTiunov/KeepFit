using System;
using System.Security.Principal;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using KeepFit.Core.Models;

namespace KeepFit.Web.Identity
{
    public class KeepFitIdentity : IIdentity, IXmlSerializable
    {
        private const string UserIdAttribute = "userId";
        private const string IndividualIdAttribute = "individualId";
        private const string RoleTypeAttribute = "roleType";
        private const string UserNameAttribute = "user";
        private const string FirstNameAttribute = "firstName";
        private const string LastNameAttribute = "lastName";
        private const string TokenAttribute = "token";
        private const string IsPasswordExpiredAttribute = "passExpired";
        private int _userId;
        private int _individualId;
        private string _userName;
        private string _firstName;
        private string _lastName;
        private string _token;
        private RoleType _roleType;
        private double bmr;

        public int UserId
        {
            get
            {
                return _userId;
            }
        }

        public int IndividualId
        {
            get
            {
                return _individualId;
            }
        }

        public string Name
        {
            get
            {
                return _userName ?? "Anonymous";
            }
        }

        public RoleType RoleType
        {
            get { return _roleType; }
        }

        public string Token
        {
            get { return _token; }
        }

        public string AuthenticationType
        {
            get
            {
                return "KeepFitIdentity";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return _token != null;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
        }

        public bool IsPasswordExpired { get; set; }

        public bool RememberMe { get; set; }

        public double BMR { get { return bmr; } }

        public KeepFitIdentity()
        {
            bmr = 0;
            _userId = -1;
            _userName = null;
            _token = null;
        }

        public KeepFitIdentity(int userId, int individualId, string userName, string firstName, string lastName, RoleType roleType, string token, double bmr, bool isPasswordExpired = false, bool rememberMe = false)
        {
            _userId = userId;
            _individualId = individualId;
            _userName = userName;
            _roleType = roleType;
            IsPasswordExpired = isPasswordExpired;
            _token = token;
            _firstName = firstName;
            _lastName = lastName;
            RememberMe = rememberMe;
            this.bmr = bmr;
        }

        public void SetBmr(double bmr)
        {
            this.bmr = bmr;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToAttribute(UserIdAttribute))
            {
                var uid = reader.GetAttribute(UserIdAttribute);
                if (!string.IsNullOrEmpty(uid))
                {
                    _userId = int.Parse(uid);
                }
            }

            if (reader.MoveToAttribute(IndividualIdAttribute))
            {
                var iid = reader.GetAttribute(IndividualIdAttribute);
                if (!string.IsNullOrEmpty(iid))
                {
                    _individualId = int.Parse(iid);
                }
            }

            if (reader.MoveToAttribute(RoleTypeAttribute))
            {
                var ut = reader.GetAttribute(RoleTypeAttribute);
                if (!string.IsNullOrEmpty(ut))
                {
                    _roleType = (RoleType)Enum.Parse(typeof(RoleType), ut);
                }
            }

            if (reader.MoveToAttribute(UserNameAttribute))
            {
                _userName = reader.GetAttribute(UserNameAttribute);
            }

            if (reader.MoveToAttribute(FirstNameAttribute))
            {
                _firstName = reader.GetAttribute(FirstNameAttribute);
            }

            if (reader.MoveToAttribute(LastNameAttribute))
            {
                _lastName = reader.GetAttribute(LastNameAttribute);
            }

            if (reader.MoveToAttribute(TokenAttribute))
            {
                _token = reader.GetAttribute(TokenAttribute);
            }

            if (reader.MoveToAttribute(IsPasswordExpiredAttribute))
            {
                var isPasswordExpired = reader.GetAttribute(IsPasswordExpiredAttribute);
                if (!string.IsNullOrEmpty(isPasswordExpired))
                {
                    IsPasswordExpired = bool.Parse(isPasswordExpired);
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            if (_userId > 0)
            {
                writer.WriteAttributeString(UserIdAttribute, _userId.ToString());
            }

            if (_individualId > 0)
            {
                writer.WriteAttributeString(IndividualIdAttribute, _individualId.ToString());
            }

            if (Enum.IsDefined(typeof(RoleType), _roleType))
            {
                writer.WriteAttributeString(RoleTypeAttribute, _roleType.ToString());
            }

            if (_userName != null)
            {
                writer.WriteAttributeString(UserNameAttribute, _userName);
            }

            if (_firstName != null)
            {
                writer.WriteAttributeString(FirstNameAttribute, _firstName);
            }

            if (_lastName != null)
            {
                writer.WriteAttributeString(LastNameAttribute, _lastName);
            }

            if (_token != null)
            {
                writer.WriteAttributeString(TokenAttribute, _token);
            }

            if (IsPasswordExpired)
            {
                writer.WriteAttributeString(IsPasswordExpiredAttribute, IsPasswordExpired.ToString());
            }
        }

        public void SetRole(RoleType role)
        {
            _roleType = role;
        }

        public void SetName(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }
    }
}