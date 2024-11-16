import { SortOrder } from "../../util/SortOrder";

export type LocationOrderByInput = {
  city?: SortOrder;
  country?: SortOrder;
  createdAt?: SortOrder;
  id?: SortOrder;
  state?: SortOrder;
  timeZone?: SortOrder;
  updatedAt?: SortOrder;
};
