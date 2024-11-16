import { Role as TRole } from "../api/role/Role";

export const ROLE_TITLE_FIELD = "roleName";

export const RoleTitle = (record: TRole): string => {
  return record.roleName?.toString() || String(record.id);
};
