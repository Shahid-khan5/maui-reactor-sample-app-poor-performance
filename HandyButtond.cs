using MauiReactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_reactor_sample_app
{
    class MudEntryState
    {
        public bool Focused { get; set; }

        public bool IsFilled { get; set; }
    }

    class HandyTextBox

        : Component<MudEntryState>
    {
        private MauiControls.Entry _entryRef;
        private Action<string> _textChangedAction;
        private string _label;
        public HandyTextBox OnTextChanged(Action<string> textChangedAction)
        {
            _textChangedAction = textChangedAction;
            return this;
        }

        public HandyTextBox Label(string label)
        {
            _label = label;
            return this;
        }
        public HandyTextBox HCenter(string label)
        {
            _label = label;
            return this;
        }

        public override VisualNode Render()
        {
            return new Grid("Auto", "*")
        {
            new Entry(entryRef => _entryRef = entryRef)
                .OnAfterTextChanged(OnTextChanged)
                .VCenter()
                .TextColor(Microsoft.Maui.Graphics.Colors.Black)
                .OnFocused(()=>SetState(s => s.Focused = true))
                .OnUnfocused(()=>SetState(s => s.Focused = false)),

            new Label(_label)
                .OnTapped(()=>_entryRef?.Focus())
                .Margin(5,0)
                .HStart()
                .TextColor(Microsoft.Maui.Graphics.Colors.Black)
                .VCenter()
                .TranslationY(State.Focused || State.IsFilled ? -20 : 0)
                .ScaleX(State.Focused || State.IsFilled ? 0.8 : 1.0)
                .AnchorX(0)
                .TextColor(!State.Focused || !State.IsFilled ? Colors.Gray : Colors.Red)
                .WithAnimation(duration: 200),
        }
            .VCenter();
        }

        private void OnTextChanged(string text)
        {
            SetState(s => s.IsFilled = !string.IsNullOrWhiteSpace(text));
            _textChangedAction?.Invoke(text);
        }
    }
}
