import React from "react";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import HolidaysCalendar from "./HolidaysCalendar";

function HolidaysIndex() {
  return (
    <>
      <Header />
      <Main>
        <HolidaysCalendar />
      </Main>
    </>
  );
}

export default HolidaysIndex;
