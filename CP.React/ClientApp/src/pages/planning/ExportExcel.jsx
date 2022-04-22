import React from "react";
import ReactExport from "react-export-excel";

const ExcelFile = ReactExport.ExcelFile;
const ExcelSheet = ReactExport.ExcelFile.ExcelSheet;
const ExcelColumn = ReactExport.ExcelFile.ExcelColumn;

const data = [
  {
    employee: { name: "Yasin", regime: "38" },
    schedules: [
      { date: "1", start: "08:00", end: "12:00" },
      { date: "2", start: "08:00", end: "12:00" },
      { date: "3", start: "08:00", end: "12:00" },
      { date: "4", start: "08:00", end: "12:00" },
      { date: "5", start: "08:00", end: "12:00" },
      { date: "6", start: "08:00", end: "12:00" },
      { date: "7", start: "08:00", end: "12:00" },
      { date: "8", start: "08:00", end: "12:00" },
      { date: "10", start: "08:00", end: "12:00" },
      { date: "11", start: "08:00", end: "12:00" },
      { date: "12", start: "08:00", end: "12:00" },
      { date: "13", start: "08:00", end: "12:00" },
      { date: "14", start: "08:00", end: "12:00" },
      { date: "15", start: "08:00", end: "12:00" },
      { date: "16", start: "08:00", end: "12:00" },
      { date: "17", start: "08:00", end: "12:00" },
      { date: "18", start: "08:00", end: "12:00" },
      { date: "19", start: "08:00", end: "12:00" },
      { date: "20", start: "08:00", end: "12:00" },
      { date: "21", start: "08:00", end: "12:00" },
      { date: "22", start: "08:00", end: "12:00" },
      { date: "23", start: "08:00", end: "12:00" },
      { date: "24", start: "08:00", end: "12:00" },
      { date: "25", start: "08:00", end: "12:00" },
      { date: "26", start: "08:00", end: "12:00" },
      { date: "27", start: "08:00", end: "12:00" },
      { date: "28", start: "08:00", end: "12:00" },
      { date: "29", start: "08:00", end: "12:00" },
      { date: "30", start: "08:00", end: "12:00" },
    ],
  },
];

export default function ExportExcel(props) {
  // const { columns, data } = props;

  return (
    <ExcelFile element={<button>Download Table</button>}>
      <ExcelSheet data={data} name="Planning">
        <ExcelColumn label="Nurse" value={(col) => col.employee.name} />
        <ExcelColumn label="Regime" value={(col) => col.employee.regime} />
        {Array.from(data[0].schedules).map((s) => (
          <ExcelColumn
            key={s.date}
            label={s.date}
            value={() => `${s.start} - ${s.end}`}
          />
        ))}
      </ExcelSheet>
    </ExcelFile>
  );
}
