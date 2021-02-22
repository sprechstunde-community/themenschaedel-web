using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Themenschaedel.Components.Controls
{
    public class CheckControl : ComponentBase
    {
        [Required] [Parameter] public string Title { get; set; }

        [Parameter] public bool IsChecked { get; set; } = false;

        [Parameter] public Action OnClickAction { get; set; } = null;

        [Parameter] public EventCallback<bool> OnClick { get; set; }

        public CheckControl()
        {
            if (OnClickAction == null) OnClickAction = new Action(OnClickInternal);

        }

        protected async void OnClickInternal()
        {
            IsChecked = !IsChecked;
            await OnClick.InvokeAsync(IsChecked);
        }

    }
}
