import { CompanySiteWhereInput } from "./CompanySiteWhereInput";
import { CompanySiteOrderByInput } from "./CompanySiteOrderByInput";

export type CompanySiteFindManyArgs = {
  where?: CompanySiteWhereInput;
  orderBy?: Array<CompanySiteOrderByInput>;
  skip?: number;
  take?: number;
};
