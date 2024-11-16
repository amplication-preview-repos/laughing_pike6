import { JsonValue } from "type-fest";

export type User = {
  avatar: JsonValue;
  createdAt: Date;
  email: string | null;
  facebook: string | null;
  firstName: string | null;
  id: string;
  lastName: string | null;
  phoneNumber: number | null;
  roles: JsonValue;
  updatedAt: Date;
  username: string;
  whatsapp: string | null;
};
