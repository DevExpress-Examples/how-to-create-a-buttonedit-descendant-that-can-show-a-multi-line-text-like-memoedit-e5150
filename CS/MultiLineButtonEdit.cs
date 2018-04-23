using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Reflection;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using System.Windows.Forms;

namespace MultilineButtonEditExample {

    [UserRepositoryItem("RegisterMultiLineButtonEdit")]
    public class RepositoryItemMultiLineButtonEdit : RepositoryItemButtonEdit {
        bool _acceptsTab;
        bool _acceptsReturn;
        int _linesCount;
        ScrollBars _scrollBars;
        public const string MultiLineButtonEditName = "MultiLineButtonEdit";

        static RepositoryItemMultiLineButtonEdit() { RegisterMultiLineButtonEdit(); }

        public RepositoryItemMultiLineButtonEdit() {
            this._acceptsTab = false;
            this._acceptsReturn = true;
            this._linesCount = 0;
            this._scrollBars = ScrollBars.None;
        }

        [Browsable(false)]
        protected override bool UseMaskBox { get { return false; } }
        [Browsable(false)]
        public override bool AutoHeight { get { return false; } }

        public override string EditorTypeName { get { return MultiLineButtonEditName; } }

        public static void RegisterMultiLineButtonEdit() {
            Image img = null;
                        try {
                            img = (Image)Bitmap.FromStream(Assembly.GetAssembly(typeof(MultiLineButtonEdit)).GetManifestResourceStream("MultilineButtonEditExample.MultiLineButtonEdit.bmp"));
                      } catch { }
              EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(MultiLineButtonEditName,
              typeof(MultiLineButtonEdit),
              typeof(RepositoryItemMultiLineButtonEdit),
              typeof(MultiLineButtonEditViewInfo),
              new ButtonEditPainter(),
              true,
              img,
              typeof(DevExpress.Accessibility.ButtonEditAccessible)));
        }

        [DefaultValue(false)]
        public bool AcceptsTab {
            get { return _acceptsTab; }
            set {
                if(AcceptsTab == value) return;
                _acceptsTab = value;
                OnPropertiesChanged();
            }
        }

        [DefaultValue(true)]
        public bool AcceptsReturn {
            get { return _acceptsReturn; }
            set {
                if(AcceptsReturn == value) return;
                _acceptsReturn = value;
                OnPropertiesChanged();
            }
        }
        
        [Browsable(false)]
        public int LinesCount {
            get { return _linesCount; }
            set {
                if(value < 1) value = 0;
                if(LinesCount == value) return;
                _linesCount = value;
                OnPropertiesChanged();
            }
        }

        public ScrollBars ScrollBars {
            get { return _scrollBars; }
            set {
                if(ScrollBars == value) return;
                _scrollBars = value;
                OnPropertiesChanged();
            }
        }

        public override void Assign(RepositoryItem item) {
            RepositoryItemMultiLineButtonEdit source = item as RepositoryItemMultiLineButtonEdit;
            BeginUpdate();
            try {
                base.Assign(item);
                if(source == null) return;
                this._acceptsReturn = source.AcceptsReturn;
                this._acceptsTab = source.AcceptsTab;
                this._scrollBars = source.ScrollBars;
                this._linesCount = source.LinesCount;
            } finally {
                EndUpdate();
            }
        }

        protected override bool NeededKeysContains(Keys key) {
            if(AcceptsReturn && key == Keys.Enter)
                return true;
            if(AcceptsTab && key == Keys.Tab)
                return true;
            if(key == Keys.Up)
                return true;
            if(key == Keys.Down)
                return true;
            return base.NeededKeysContains(key);
        }

        protected override bool IsNeededKeyCore(Keys keyData) {
            if(keyData == (Keys.Enter | Keys.Control)) return false;
            bool res = base.IsNeededKeyCore(keyData);
            if(res) return true;
            if(keyData == Keys.PageUp || keyData == Keys.PageDown) return true;
            return false;
        }
    }

    public class MultiLineButtonEditViewInfo : ButtonEditViewInfo, IHeightAdaptable {

        public MultiLineButtonEditViewInfo(RepositoryItem item) : base(item) { }
        public new RepositoryItemMultiLineButtonEdit Item { get { return base.Item as RepositoryItemMultiLineButtonEdit; } }

        static TextOptions defaultEditTextOptions;
        static TextOptions DefaultEditTextOptions {
            get {
                if(defaultEditTextOptions == null) {
                    defaultEditTextOptions = new TextOptions(HorzAlignment.Near, VertAlignment.Top, WordWrap.Wrap, Trimming.None);
                }
                return defaultEditTextOptions;
            }
        }
        public override TextOptions DefaultTextOptions {
            get {
                if(OwnerEdit != null && OwnerEdit.InplaceType == InplaceType.Standalone) {
                    if(Item.ScrollBars == ScrollBars.Horizontal || Item.ScrollBars == ScrollBars.Both) {
                        return new TextOptions(HorzAlignment.Near, VertAlignment.Top, WordWrap.NoWrap, Trimming.None);
                    }
                }
                return DefaultEditTextOptions;
            }
        }

        protected override void CalcContentRect(Rectangle bounds) {
            base.CalcContentRect(bounds);
            this.fMaskBoxRect = ContentRect;
            if(!(BorderPainter is EmptyBorderPainter))
                this.fMaskBoxRect.Inflate(-1, -1);
        }

        int IHeightAdaptable.CalcHeight(GraphicsCache cache, int width) {
                BorderObjectInfoArgs info = new BorderObjectInfoArgs(cache);
                info.Bounds = new Rectangle(0, 0, ContentRect.Width, 100);
            Rectangle textRect = BorderPainter.GetObjectClientRectangle(info);
            if(!(BorderPainter is EmptyBorderPainter) && !(BorderPainter is InplaceBorderPainter))
                textRect.Inflate(-1, -1);
            string text = string.Empty;
            if(Item.LinesCount == 0) {
                text = DisplayText;
                if(text != null && text.Length > 0) {
                    char lastChar = text[text.Length - 1];
                    if(lastChar == 13 || lastChar == 10) text += "W";
                }
            } else {
                for(int i = 0; i < Item.LinesCount; i++)
                    text += (string.IsNullOrEmpty(text) ? "" : Environment.NewLine) + "W";
            }
            int height = CalcTextSizeCore(cache, text, textRect.Width).Height + 1;
            return (height + 100 - textRect.Bottom) + 1;
        }
    }

    [ToolboxBitmapAttribute(typeof(MultiLineButtonEdit), "MultiLineButtonEdit.bmp")]
    [ToolboxItem(true)]
    [Description("Custom ButtonEdit with multi line support.")]
    public class MultiLineButtonEdit : ButtonEdit {
        static MultiLineButtonEdit() { RepositoryItemMultiLineButtonEdit.RegisterMultiLineButtonEdit(); }
        public MultiLineButtonEdit() { }
        public override string EditorTypeName { get { return RepositoryItemMultiLineButtonEdit.MultiLineButtonEditName; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemMultiLineButtonEdit Properties {
            get { return base.Properties as RepositoryItemMultiLineButtonEdit; }
        }
        protected override bool AcceptsReturn { get { return Properties.AcceptsReturn; } }
        protected override bool AcceptsTab { get { return Properties.AcceptsTab; } }

        protected override void UpdateMaskBoxProperties(bool always) {
            base.UpdateMaskBoxProperties(always);
            if(MaskBox == null) return;
            if(always || !MaskBox.Multiline) MaskBox.Multiline = true;
            if(always || !MaskBox.WordWrap) MaskBox.WordWrap = true;
            if(always || Properties.AcceptsTab != MaskBox.AcceptsTab) MaskBox.AcceptsTab = Properties.AcceptsTab;
            if(always || Properties.AcceptsReturn != MaskBox.AcceptsReturn) MaskBox.AcceptsReturn = Properties.AcceptsReturn;
            if(always || Properties.ScrollBars != MaskBox.ScrollBars) MaskBox.ScrollBars = Properties.ScrollBars;
        }

        protected override bool IsInputKey(Keys keyData) {
            bool result = base.IsInputKey(keyData);
            if(result) return true;
            if(Properties.AcceptsReturn && keyData == Keys.Enter) return true;
            if(Properties.AcceptsTab && keyData == Keys.Tab) return true;
            return result;
        }
    }
}
