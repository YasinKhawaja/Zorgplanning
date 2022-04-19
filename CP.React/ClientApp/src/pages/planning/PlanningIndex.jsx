import React from "react";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import PlanningWizard from "./PlanningWizard";

function PlanningIndex() {
  return (
    <React.Fragment>
      <Header />
      <Main>
        <PlanningWizard />
      </Main>
    </React.Fragment>
  );
}

export default PlanningIndex;
