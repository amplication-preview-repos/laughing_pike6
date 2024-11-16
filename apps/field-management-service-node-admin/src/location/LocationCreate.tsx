import * as React from "react";
import { Create, SimpleForm, CreateProps, TextInput } from "react-admin";

export const LocationCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput label="city" source="city" />
        <TextInput label="country" source="country" />
        <TextInput label="state" source="state" />
        <TextInput label="timeZone" source="timeZone" />
      </SimpleForm>
    </Create>
  );
};
