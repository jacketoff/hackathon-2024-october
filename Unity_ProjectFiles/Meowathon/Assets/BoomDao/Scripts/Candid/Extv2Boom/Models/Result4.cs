using EdjCase.ICP.Candid.Mapping;
using Candid.Extv2Boom.Models;
using System;

namespace Candid.Extv2Boom.Models
{
	[Variant]
	public class Result4
	{
		[VariantTagProperty]
		public Result4Tag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public Result4(Result4Tag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected Result4()
		{
		}

		public static Result4 Err(string info)
		{
			return new Result4(Result4Tag.Err, info);
		}

		public static Result4 Ok()
		{
			return new Result4(Result4Tag.Ok, null);
		}

		public string AsErr()
		{
			this.ValidateTag(Result4Tag.Err);
			return (string)this.Value!;
		}

		private void ValidateTag(Result4Tag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum Result4Tag
	{
		[CandidName("err")]
		Err,
		[CandidName("ok")]
		Ok
	}
}