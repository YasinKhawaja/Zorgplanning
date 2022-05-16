import React from "react";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import Features from "./Features";

export default function Dashboard() {
  return (
    <>
      <Header />
      <Main>
        <Features />
      </Main>
    </>
  );
}
