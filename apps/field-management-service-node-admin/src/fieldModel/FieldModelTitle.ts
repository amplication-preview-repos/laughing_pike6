import { FieldModel as TFieldModel } from "../api/fieldModel/FieldModel";

export const FIELDMODEL_TITLE_FIELD = "surfaceType";

export const FieldModelTitle = (record: TFieldModel): string => {
  return record.surfaceType?.toString() || String(record.id);
};
