import { JsonFilter } from "../../util/JsonFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { IntNullableFilter } from "../../util/IntNullableFilter";

export type UserWhereInput = {
  avatar?: JsonFilter;
  email?: StringNullableFilter;
  facebook?: StringNullableFilter;
  firstName?: StringNullableFilter;
  id?: StringFilter;
  lastName?: StringNullableFilter;
  phoneNumber?: IntNullableFilter;
  username?: StringFilter;
  whatsapp?: StringNullableFilter;
};
