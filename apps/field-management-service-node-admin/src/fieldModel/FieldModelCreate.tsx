import * as React from "react";
import {
  Create,
  SimpleForm,
  CreateProps,
  NumberInput,
  TextInput,
} from "react-admin";

export const FieldModelCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <NumberInput step={1} label="capacity" source="capacity" />
        <NumberInput label="price" source="price" />
        <div />
        <TextInput label="surfaceType" source="surfaceType" />
      </SimpleForm>
    </Create>
  );
};
