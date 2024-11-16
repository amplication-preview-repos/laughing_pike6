import { InputJsonValue } from "../../types";

export type UserCreateInput = {
  avatar?: InputJsonValue;
  email?: string | null;
  facebook?: string | null;
  firstName?: string | null;
  lastName?: string | null;
  password: string;
  phoneNumber?: number | null;
  roles: InputJsonValue;
  username: string;
  whatsapp?: string | null;
};
