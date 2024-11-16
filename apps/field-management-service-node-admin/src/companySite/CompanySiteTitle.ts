import { CompanySite as TCompanySite } from "../api/companySite/CompanySite";

export const COMPANYSITE_TITLE_FIELD = "name";

export const CompanySiteTitle = (record: TCompanySite): string => {
  return record.name?.toString() || String(record.id);
};
