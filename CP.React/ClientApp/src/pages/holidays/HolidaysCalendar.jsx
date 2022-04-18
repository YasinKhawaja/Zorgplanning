import FullCalendar from "@fullcalendar/react"; // MUST BE IMPORTED BEFORE PLUGINS
import bootstrap5Plugin from "@fullcalendar/bootstrap5";
import dayGridPlugin from "@fullcalendar/daygrid";
import interactionPlugin from "@fullcalendar/interaction";
import timeGridPlugin from "@fullcalendar/timegrid";
import "bootstrap-icons/font/bootstrap-icons.css";
import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import EmployeeService from "../../services/EmployeeService";
import { createEventId } from "../calendar/event-utils";
import HolidayFormDialog from "./HolidayFormDialog";
import { getRandomColor } from "./utils";

function HolidaysCalendar(props) {
  const [events, setEvents] = React.useState(null);
  const [isPending, setIsPending] = React.useState(true);
  const [apiErrors, setApiErrors] = React.useState(null);
  const [openFormDialog, setOpenFormDialog] = React.useState(false);
  const [selectedDay, setSelectedDay] = React.useState(null);

  React.useEffect(() => {
    setEvents([
      {
        id: 1,
        title: "Test",
        start: new Date(),
        allDay: true,
        color: getRandomColor(),
      },
    ]);
  }, []);

  function fetchEvents() {
    EmployeeService.getAllAbsences(1)
      .then((response) => {
        let absences = response.data.result;
        let events = [];
        absences.forEach((element) => {
          events.push({
            id: createEventId(),
            title: element.type,
            start: new Date(element.day),
            allDay: true,
            color: getRandomColor(),
          });
        });
        setEvents(events);
        setIsPending(false);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  const handleEventClick = (clickInfo) => {
    if (
      window.confirm(
        `Are you sure you want to delete the absence ${clickInfo.event.title} on ${clickInfo.event.startStr}?`
      )
    ) {
      // clickInfo.event.remove(); // Remove from calendar
      handleRemove(clickInfo.event); // Remove from database
    }
  };

  const handleRemove = (event) => {
    EmployeeService.removeAbsence(props.employee.id, event.startStr)
      .then(() => {
        fetchEvents();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const handleAddOrEdit = (values, resetFormFn) => {
    const absence = {
      ...values,
      employeeId: props.employee.id,
      day: selectedDay.dateStr,
    };
    const data = JSON.stringify(absence);
    EmployeeService.createAbsence(props.employee.id, data)
      .then((response) => {
        resetFormFn();
        setOpenFormDialog(false);
        fetchEvents();
      })
      .catch((error) => {
        setApiErrors(
          error.response.data.responseException.exceptionMessage.errors
        );
      });
  };

  function renderEventContent(eventInfo) {
    return (
      <>
        &nbsp;
        <i>
          <b>{eventInfo.event.title}</b>
        </i>
      </>
    );
  }

  function handleDateClick() {
    setOpenFormDialog(true);
  }

  return (
    <>
      <FullCalendar
        plugins={[
          bootstrap5Plugin,
          dayGridPlugin,
          interactionPlugin,
          timeGridPlugin,
        ]}
        // DISPLAY
        themeSystem="bootstrap5"
        headerToolbar={{
          left: "prev,next today",
          center: "title",
          right: "dayGridMonth,timeGridWeek,timeGridDay",
        }}
        height={700}
        navLinks
        // EVENTS
        events={events}
        eventContent={renderEventContent}
        dateClick={handleDateClick}
        eventClick={handleEventClick}
      />
      <HolidayFormDialog open={openFormDialog} onClose={setOpenFormDialog} />
    </>
  );
}

export default HolidaysCalendar;
