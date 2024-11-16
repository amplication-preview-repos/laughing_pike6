import { Location as TLocation } from "../api/location/Location";

export const LOCATION_TITLE_FIELD = "city";

export const LocationTitle = (record: TLocation): string => {
  return record.city?.toString() || String(record.id);
};
