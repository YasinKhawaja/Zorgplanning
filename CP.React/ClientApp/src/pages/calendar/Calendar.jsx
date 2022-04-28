import FullCalendar, { formatDate } from "@fullcalendar/react"; // MUST BE IMPORTED BEFORE PLUGINS
import bootstrap5Plugin from "@fullcalendar/bootstrap5";
import dayGridPlugin from "@fullcalendar/daygrid";
import interactionPlugin from "@fullcalendar/interaction";
import timeGridPlugin from "@fullcalendar/timegrid";
import "bootstrap-icons/font/bootstrap-icons.css";
import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import Dialog from "../../components/presentations/Dialog";
import EmployeeService from "../../services/EmployeeService";
import AbsenceForm from "./AbsenceForm";
import { createEventId } from "./event-utils";

export default function Calendar(props) {
  const [apiErrors, setApiErrors] = React.useState(null);
  const [events, setEvents] = React.useState(null);
  const [isPending, setIsPending] = React.useState(true);
  const [openAddOrEditDialog, setOpenAddOrEditDialog] = React.useState(false);
  const [selectedDay, setSelectedDay] = React.useState(null);
  const [weekendsVisible, setWeekendsVisible] = React.useState(true);

  React.useEffect(() => {
    fetchEvents();
  }, [setEvents]);

  const fetchEvents = () => {
    EmployeeService.getAllAbsences(props.employee.id)
      .then((response) => {
        let absences = response.data.result;
        let events = [];
        absences.forEach((element) => {
          events.push({
            id: createEventId(),
            title: element.type,
            start: new Date(element.day),
            allDay: true,
            backgroundColor: getColor(element),
            borderColor: getColor(element),
          });
        });
        setEvents(events);
        setIsPending(false);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const getColor = (absence) => {
    let color = "";
    switch (absence.type) {
      case "Leave":
        color = "#228B22";
        break;
      case "Sickness":
        color = "#FF0000";
        break;
      case "WorkingTimeReduction":
        color = "#0000FF";
      default:
        break;
    }
    return color;
  };

  const handleWeekendsToggle = () => {
    setWeekendsVisible(!weekendsVisible);
  };

  const handleDateSelect = (selectInfo) => {
    setOpenAddOrEditDialog(true);
    setSelectedDay(selectInfo);
  };

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
        setOpenAddOrEditDialog(false);
        fetchEvents();
      })
      .catch((error) => {
        setApiErrors(error.response.data.errors);
      });
  };

  const renderSidebar = () => {
    return (
      <div className="demo-app-sidebar">
        <div className="demo-app-sidebar-section">
          <h2>Instructions</h2>
          <ul>
            <li>Select dates and you will be prompted to create a new event</li>
            <li>Drag, drop, and resize events</li>
            <li>Click an event to delete it</li>
          </ul>
        </div>
        <div className="demo-app-sidebar-section">
          <label>
            <input
              type="checkbox"
              checked={weekendsVisible}
              onChange={handleWeekendsToggle}
            ></input>
            toggle weekends
          </label>
        </div>
        <div className="demo-app-sidebar-section">
          <h2>All Events ({events.length})</h2>
          <ul>{events.map(renderSidebarEvent)}</ul>
        </div>
      </div>
    );
  };

  const renderSidebarEvent = (event) => {
    return (
      <li key={event.id}>
        <b>
          {formatDate(event.start, {
            year: "numeric",
            month: "short",
            day: "numeric",
          })}
        </b>
        <i>{event.title}</i>
      </li>
    );
  };

  const renderEventContent = (eventInfo) => {
    return (
      <>
        &nbsp;<i>{eventInfo.event.title}</i>
      </>
    );
  };

  return (
    <>
      {!isPending && (
        <div className="demo-app">
          {/* {this.renderSidebar()} */}
          <div className="demo-app-main">
            <FullCalendar
              plugins={[
                bootstrap5Plugin,
                dayGridPlugin,
                timeGridPlugin,
                interactionPlugin,
              ]}
              // DISPLAY
              headerToolbar={{
                left: "prev,next today",
                center: "title",
                right: "dayGridMonth,timeGridWeek,timeGridDay",
              }}
              height={700}
              initialView="dayGridMonth"
              navLinks
              themeSystem="bootstrap5"
              // EVENTS
              dateClick={handleDateSelect}
              eventClick={handleEventClick}
              eventContent={renderEventContent}
              // eventsSet={handleEvents} // called after events are initialized/added/changed/removed
              events={events}
              weekends={weekendsVisible}
            />
          </div>
        </div>
      )}
      <Dialog
        sx={{
          "& .css-1fu2e3p-MuiPaper-root-MuiDialog-paper": {
            minWidth: "500px",
          },
        }}
        title="Add Absence"
        openDialog={openAddOrEditDialog}
        setOpenDialog={setOpenAddOrEditDialog}
      >
        <AbsenceForm onAddOrEdit={handleAddOrEdit} apiErrors={apiErrors} />
      </Dialog>
    </>
  );
}
