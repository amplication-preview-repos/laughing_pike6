import { InputJsonValue } from "../../types";

export type FieldModelCreateInput = {
  capacity?: number | null;
  price?: number | null;
  servicesAvailability?: InputJsonValue;
  surfaceType?: string | null;
};
