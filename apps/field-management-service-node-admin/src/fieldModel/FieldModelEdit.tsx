import * as React from "react";
import {
  Edit,
  SimpleForm,
  EditProps,
  NumberInput,
  TextInput,
} from "react-admin";

export const FieldModelEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <NumberInput step={1} label="capacity" source="capacity" />
        <NumberInput label="price" source="price" />
        <div />
        <TextInput label="surfaceType" source="surfaceType" />
      </SimpleForm>
    </Edit>
  );
};
