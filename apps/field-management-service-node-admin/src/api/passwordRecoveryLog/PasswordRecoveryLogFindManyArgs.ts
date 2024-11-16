import { PasswordRecoveryLogWhereInput } from "./PasswordRecoveryLogWhereInput";
import { PasswordRecoveryLogOrderByInput } from "./PasswordRecoveryLogOrderByInput";

export type PasswordRecoveryLogFindManyArgs = {
  where?: PasswordRecoveryLogWhereInput;
  orderBy?: Array<PasswordRecoveryLogOrderByInput>;
  skip?: number;
  take?: number;
};
