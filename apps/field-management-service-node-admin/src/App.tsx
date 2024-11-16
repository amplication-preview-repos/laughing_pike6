import React, { useEffect, useState } from "react";
import { Admin, DataProvider, Resource } from "react-admin";
import dataProvider from "./data-provider/graphqlDataProvider";
import { theme } from "./theme/theme";
import Login from "./Login";
import "./App.scss";
import Dashboard from "./pages/Dashboard";
import { LocationList } from "./location/LocationList";
import { LocationCreate } from "./location/LocationCreate";
import { LocationEdit } from "./location/LocationEdit";
import { LocationShow } from "./location/LocationShow";
import { RoleList } from "./role/RoleList";
import { RoleCreate } from "./role/RoleCreate";
import { RoleEdit } from "./role/RoleEdit";
import { RoleShow } from "./role/RoleShow";
import { CompanySiteList } from "./companySite/CompanySiteList";
import { CompanySiteCreate } from "./companySite/CompanySiteCreate";
import { CompanySiteEdit } from "./companySite/CompanySiteEdit";
import { CompanySiteShow } from "./companySite/CompanySiteShow";
import { TransactionList } from "./transaction/TransactionList";
import { TransactionCreate } from "./transaction/TransactionCreate";
import { TransactionEdit } from "./transaction/TransactionEdit";
import { TransactionShow } from "./transaction/TransactionShow";
import { TeamList } from "./team/TeamList";
import { TeamCreate } from "./team/TeamCreate";
import { TeamEdit } from "./team/TeamEdit";
import { TeamShow } from "./team/TeamShow";
import { RatingList } from "./rating/RatingList";
import { RatingCreate } from "./rating/RatingCreate";
import { RatingEdit } from "./rating/RatingEdit";
import { RatingShow } from "./rating/RatingShow";
import { BookingList } from "./booking/BookingList";
import { BookingCreate } from "./booking/BookingCreate";
import { BookingEdit } from "./booking/BookingEdit";
import { BookingShow } from "./booking/BookingShow";
import { FieldModelList } from "./fieldModel/FieldModelList";
import { FieldModelCreate } from "./fieldModel/FieldModelCreate";
import { FieldModelEdit } from "./fieldModel/FieldModelEdit";
import { FieldModelShow } from "./fieldModel/FieldModelShow";
import { PasswordRecoveryLogList } from "./passwordRecoveryLog/PasswordRecoveryLogList";
import { PasswordRecoveryLogCreate } from "./passwordRecoveryLog/PasswordRecoveryLogCreate";
import { PasswordRecoveryLogEdit } from "./passwordRecoveryLog/PasswordRecoveryLogEdit";
import { PasswordRecoveryLogShow } from "./passwordRecoveryLog/PasswordRecoveryLogShow";
import { UserList } from "./user/UserList";
import { UserCreate } from "./user/UserCreate";
import { UserEdit } from "./user/UserEdit";
import { UserShow } from "./user/UserShow";
import { jwtAuthProvider } from "./auth-provider/ra-auth-jwt";

const App = (): React.ReactElement => {
  return (
    <div className="App">
      <Admin
        title={"FieldManagementServiceNode"}
        dataProvider={dataProvider}
        authProvider={jwtAuthProvider}
        theme={theme}
        dashboard={Dashboard}
        loginPage={Login}
      >
        <Resource
          name="Location"
          list={LocationList}
          edit={LocationEdit}
          create={LocationCreate}
          show={LocationShow}
        />
        <Resource
          name="Role"
          list={RoleList}
          edit={RoleEdit}
          create={RoleCreate}
          show={RoleShow}
        />
        <Resource
          name="CompanySite"
          list={CompanySiteList}
          edit={CompanySiteEdit}
          create={CompanySiteCreate}
          show={CompanySiteShow}
        />
        <Resource
          name="Transaction"
          list={TransactionList}
          edit={TransactionEdit}
          create={TransactionCreate}
          show={TransactionShow}
        />
        <Resource
          name="Team"
          list={TeamList}
          edit={TeamEdit}
          create={TeamCreate}
          show={TeamShow}
        />
        <Resource
          name="Rating"
          list={RatingList}
          edit={RatingEdit}
          create={RatingCreate}
          show={RatingShow}
        />
        <Resource
          name="Booking"
          list={BookingList}
          edit={BookingEdit}
          create={BookingCreate}
          show={BookingShow}
        />
        <Resource
          name="FieldModel"
          list={FieldModelList}
          edit={FieldModelEdit}
          create={FieldModelCreate}
          show={FieldModelShow}
        />
        <Resource
          name="PasswordRecoveryLog"
          list={PasswordRecoveryLogList}
          edit={PasswordRecoveryLogEdit}
          create={PasswordRecoveryLogCreate}
          show={PasswordRecoveryLogShow}
        />
        <Resource
          name="User"
          list={UserList}
          edit={UserEdit}
          create={UserCreate}
          show={UserShow}
        />
      </Admin>
    </div>
  );
};

export default App;
