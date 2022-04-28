import React from "react";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import HolidaysCalendar from "./HolidaysCalendar";

export default function HolidaysIndex() {
  return (
    <>
      <Header />
      <Main>
        <HolidaysCalendar />
      </Main>
    </>
  );
}
