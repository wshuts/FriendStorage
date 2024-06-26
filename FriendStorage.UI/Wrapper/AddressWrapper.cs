﻿using FriendStorage.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UI.Wrapper
{
  public class AddressWrapper : ModelWrapper<Address>
  {
    public AddressWrapper(Address model) : base(model)
    {
    }

    public int Id
    {
      get { return GetValue<int>(); }
      set { SetValue(value); }
    }

    public int IdOriginalValue => GetOriginalValue<int>(nameof(Id));

    public bool IdIsChanged => GetIsChanged(nameof(Id));

    [Required(ErrorMessage ="City is required")]
    public string City
    {
      get { return GetValue<string>(); }
      set { SetValue(value); }
    }

    public string CityOriginalValue => GetOriginalValue<string>(nameof(City));

    public bool CityIsChanged => GetIsChanged(nameof(City));

    public string Street
    {
      get { return GetValue<string>(); }
      set { SetValue(value); }
    }

    public string StreetOriginalValue => GetOriginalValue<string>(nameof(Street));

    public bool StreetIsChanged => GetIsChanged(nameof(Street));

    public string StreetNumber
    {
      get { return GetValue<string>(); }
      set { SetValue(value); }
    }

    public string StreetNumberOriginalValue => GetOriginalValue<string>(nameof(StreetNumber));

    public bool StreetNumberIsChanged => GetIsChanged(nameof(StreetNumber));
  }
}
