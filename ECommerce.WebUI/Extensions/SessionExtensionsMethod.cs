﻿using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ECommerce.WebUI.Extensions;


public static class SessionExtensionsMethod
{
	public static void SetObject(this ISession session, string key, object value)
	{
		string objectString = JsonConvert.SerializeObject(value);
		session.SetString(key, objectString);
	}

	public static T GetObject<T>(this ISession session, string key) where T : class
	{
		string objectString = session.GetString(key);
		if(string.IsNullOrEmpty(objectString))
			return null;
		T result = JsonConvert.DeserializeObject<T>(objectString);
		return result;
	}
}
