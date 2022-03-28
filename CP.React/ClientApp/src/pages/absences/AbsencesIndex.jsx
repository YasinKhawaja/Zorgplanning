import PeopleAltIcon from "@mui/icons-material/PeopleAlt";
import React from "react";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import PageHeader from "../../components/presentations/PageHeader";
import DemoApp from "./Absences";

export default function AbsencesIndex() {
  return (
    <>
      <Header />
      {/* {!isPending && ( */}
      <>
        <PageHeader
          icon={<PeopleAltIcon fontSize="large" />}
          title="Nurses"
          subtitle={`All nurses in team .`}
        />
        <Main>
          <DemoApp />
        </Main>
      </>
      {/* )} */}
    </>
  );
}
