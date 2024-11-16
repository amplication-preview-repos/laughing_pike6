import { PasswordRecoveryLog as TPasswordRecoveryLog } from "../api/passwordRecoveryLog/PasswordRecoveryLog";

export const PASSWORDRECOVERYLOG_TITLE_FIELD = "id";

export const PasswordRecoveryLogTitle = (
  record: TPasswordRecoveryLog
): string => {
  return record.id?.toString() || String(record.id);
};
