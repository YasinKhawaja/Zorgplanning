import React from "react";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import Teams from "./Teams";

export default function TeamsIndex() {
  return (
    <>
      <Header />
      <Main>
        <Teams />
      </Main>
    </>
  );
}
