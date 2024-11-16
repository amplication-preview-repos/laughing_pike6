import { JsonValue } from "type-fest";

export type FieldModel = {
  capacity: number | null;
  createdAt: Date;
  id: string;
  price: number | null;
  servicesAvailability: JsonValue;
  surfaceType: string | null;
  updatedAt: Date;
};
