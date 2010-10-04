using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Xml.Serialization;
using CslaGenerator.Attributes;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
	/// <summary>
	/// Summary description for ChildProperty.
	/// </summary>
	[Serializable]
	public class ChildProperty : Property
	{
		private LoadingScheme _loadingScheme = LoadingScheme.ParentLoad;
        private PropertyDeclaration _declarationMode;
		private bool _lazyLoad;
		private string _typeName = String.Empty;
		private bool _undoable = true;
		private ParameterCollection _loadParameters = new ParameterCollection();
		private PropertyAccess _access = PropertyAccess.IsPublic;

        [Category("01. Definition")]
        [Description("The property name.")]
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        [Category("01. Definition")]
        [Description("This is a description.")]
        [UserFriendlyName("Type Name")]
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

        [Category("01. Definition")]
        [Description("Property Declaration Mode. For child properties should be \"Managed\" or \"ManagedWithTypeConversion\".")]
        [UserFriendlyName("Declaration Mode")]
        public PropertyDeclaration DeclarationMode
        {
            get { return _declarationMode; }
            set { _declarationMode = value; }
        }

        [Category("01. Definition")]
        [Description("This is a description.")]
        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set { base.ReadOnly = value; }
        }

        [Category("01. Definition")]
        [Description("Whether this property can have a null value. The following types aren't nullable: \"String \", \"ByteArray \", \"SmartDate \", \"DBNull \", \"Object\" and \"Empty\".")]
        public override bool Nullable
        {
            get { return base.Nullable; }
            set { base.Nullable = value; }
        }

        [Category("05. Options")]
        [Description("This is a description.")]
        [UserFriendlyName("Lazy Load")]
        public bool LazyLoad
        {
            get { return _lazyLoad; }
            set { _lazyLoad = value; }
        }

        [Category("05. Options")]
        [Description("This is a description.")]
        [UserFriendlyName("Loading Scheme")]
        public LoadingScheme LoadingScheme
		{
			get { return _loadingScheme; }
			set { _loadingScheme = value; }
		}

		[Category("05. Options")]
		[Editor(typeof(ParameterCollectionEditor),typeof(UITypeEditor))]
		[TypeConverter(typeof(ParameterCollectionConverter))]
        [Description("This is a description.")]
        [UserFriendlyName("Load Parameters")]
        public ParameterCollection LoadParameters
		{
			get { return _loadParameters; }
			set { _loadParameters = value; }
		}

		[Category("05. Options")]
        [Description("Accessibility for the property as a whole.")]
        [UserFriendlyName("Property Access.")]
        public PropertyAccess Access
		{
			get { return _access; }
			set { _access = value; }
		}

        [Category("05. Options")]
        [Description("This is a description.")]
        public bool Undoable
        {
            get { return _undoable; }
            set { _undoable = value; }
        }

        // Hide PropertyType
        [Browsable(false)]
        public override TypeCodeEx PropertyType
        {
            get { return TypeCodeEx.Empty; }
        }

        public override object Clone()
		{
			var buffer = new MemoryStream();
			var ser = new XmlSerializer(typeof(ChildProperty));
			ser.Serialize(buffer, this);
			buffer.Position = 0;
			return ser.Deserialize(buffer);
		}

	}
}