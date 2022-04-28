import React from "react";
import ReactExport from "react-export-excel";
import { downloadFile } from "./export";

const ExcelFile = ReactExport.ExcelFile;
const ExcelSheet = ReactExport.ExcelFile.ExcelSheet;
const ExcelColumn = ReactExport.ExcelFile.ExcelColumn;

export default function ExportExcel(props) {
  const { data } = props;

  const handleClick = async () => {
    const a = await downloadFile(
      "https://localhost:7224/api/planning/export/excel?teamId=1&year=1&month=1",
      { method: "GET", headers: { "Content-Type": "application/json" } }
    );
    console.log(a);
  };

  return (
    <button onClick={handleClick}>Download Table</button>
    // <ExcelFile element={<button>Download Table</button>}>
    //   <ExcelSheet data={data} name="Planning">
    //     <ExcelColumn label="Nurse" value={(col) => col.employee.name} />
    //     <ExcelColumn label="Regime" value={(col) => col.employee.regime} />
    //     {Array.from(data[0].schedules).map((s) => (
    //       <ExcelColumn
    //         key={s.date}
    //         label={s.date}
    //         value={() => `${s.start} - ${s.end}`}
    //       />
    //     ))}
    //   </ExcelSheet>
    // </ExcelFile>
  );
}
