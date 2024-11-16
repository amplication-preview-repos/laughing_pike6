import { InputJsonValue } from "../../types";

export type FieldModelUpdateInput = {
  capacity?: number | null;
  price?: number | null;
  servicesAvailability?: InputJsonValue;
  surfaceType?: string | null;
};
