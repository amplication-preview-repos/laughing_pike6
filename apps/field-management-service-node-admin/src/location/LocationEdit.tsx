import * as React from "react";
import { Edit, SimpleForm, EditProps, TextInput } from "react-admin";

export const LocationEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput label="city" source="city" />
        <TextInput label="country" source="country" />
        <TextInput label="state" source="state" />
        <TextInput label="timeZone" source="timeZone" />
      </SimpleForm>
    </Edit>
  );
};
