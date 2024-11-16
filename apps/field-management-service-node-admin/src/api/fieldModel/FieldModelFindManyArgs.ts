import { FieldModelWhereInput } from "./FieldModelWhereInput";
import { FieldModelOrderByInput } from "./FieldModelOrderByInput";

export type FieldModelFindManyArgs = {
  where?: FieldModelWhereInput;
  orderBy?: Array<FieldModelOrderByInput>;
  skip?: number;
  take?: number;
};
