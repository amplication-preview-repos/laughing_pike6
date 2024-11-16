import { StringNullableFilter } from "../../util/StringNullableFilter";
import { StringFilter } from "../../util/StringFilter";

export type LocationWhereInput = {
  city?: StringNullableFilter;
  country?: StringNullableFilter;
  id?: StringFilter;
  state?: StringNullableFilter;
  timeZone?: StringNullableFilter;
};
