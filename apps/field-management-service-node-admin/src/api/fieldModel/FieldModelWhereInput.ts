import { IntNullableFilter } from "../../util/IntNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { FloatNullableFilter } from "../../util/FloatNullableFilter";
import { JsonFilter } from "../../util/JsonFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";

export type FieldModelWhereInput = {
  capacity?: IntNullableFilter;
  id?: StringFilter;
  price?: FloatNullableFilter;
  servicesAvailability?: JsonFilter;
  surfaceType?: StringNullableFilter;
};
