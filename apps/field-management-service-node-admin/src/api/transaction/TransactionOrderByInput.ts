import { SortOrder } from "../../util/SortOrder";

export type TransactionOrderByInput = {
  createdAt?: SortOrder;
  id?: SortOrder;
  updatedAt?: SortOrder;
};
