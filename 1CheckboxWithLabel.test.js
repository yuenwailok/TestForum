'use strict';

const shallow = require('./node_modules/enzyme');
const React = require('./node_modules/react');
const CheckboxWithLabel = require('./CheckboxWithLabel');
const Adapter = require('./node_modules/enzyme-adapter-react-16');
const recordlist = require('./recordtestclone1');
const renderer = require('./node_modules/react-test-renderer');

shallow.configure({ adapter: new Adapter() });
const record = {
    "id": "3",
    "start_date": "2018-02-16",
    "end_date": "2018-4-15",
    "rent": 820,
    "frequency": "fortnightly",
    "payment_day": "friday"
  }; 
  
test('SummaryTable should display elements', function() {

  var component = renderer.create(React.createElement(recordlist.SummaryTable, { obj: record }));  
  var tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});


test('SummaryTable should not display', function () {

  var component = renderer.create(React.createElement(recordlist.SummaryTable, { obj: null }));  
  var tree = component.toJSON();
  expect(tree).toMatchSnapshot();
  
});

test('SummaryTable should return single <p> only',function() 
{
	let component = shallow.mount(React.createElement(recordlist.SummaryTable, { obj: null }));
	expect(component.find('p').length).toBe(1);
}
);

test('SummaryTable should return a table with the property displayed',function() 
{
	let component = shallow.mount(React.createElement(recordlist.SummaryTable, { obj: record }));
	expect(component.find('p').length).toBe(1);
	expect(component.find('table').length).toBe(1);
	expect(component.find('tr').length).toBe(Object.getOwnPropertyNames(record).length);
	expect(component.find('td').length).toBe(Object.getOwnPropertyNames(record).length*2);
}
);

test('PaymentTable should display payments',function()
{
	let component = renderer.create(React.createElement(recordlist.PaymentTable, { record: recordlist.recordList(record) }));
	let tree = component.toJSON();
	expect(tree).toMatchSnapshot();
}
);

test('PaymentTable should display error',function()
{
	let component = renderer.create(React.createElement(recordlist.PaymentTable, { record: null }));
	let tree = component.toJSON();
	expect(tree).toMatchSnapshot();
}
);

test('PaymentTable should display nothing',function()
{
	let component = renderer.create(React.createElement(recordlist.PaymentTable, { record: [] }));
	let tree = component.toJSON();
	expect(tree).toMatchSnapshot();
}
);

test('PaymentTable should return single <p> only',function() 
{
	let component = shallow.mount(React.createElement(recordlist.PaymentTable, { record: null }));
	expect(component.find('p').length).toBe(1);
}
);

test('PaymentTable should return list of payment',function() 
{
	let component = shallow.mount(React.createElement(recordlist.PaymentTable, { record: recordlist.recordList(record) }));
	expect(component.find('td').length).toBe(recordlist.recordList(record).length * 4);
}
);

test('string have symbol,empty,larger than 8 should return false',function()
{
	expect(recordlist.isValidate("1111.11")).toBe(false);
	expect(recordlist.isValidate(" 1s1 11")).toBe(false);
	expect(recordlist.isValidate("")).toBe(false);
	expect(recordlist.isValidate("aaaaaaaaaaaaaaaaa")).toBe(false);
}
);

test('these string should return true',function()
{
	expect(recordlist.isValidate("111111")).toBe(true);
	expect(recordlist.isValidate("11")).toBe(true);
	expect(recordlist.isValidate("aaaaa")).toBe(true);
	expect(recordlist.isValidate("aa1451aa")).toBe(true);
}
);

test('DisplayRecord (have error)',function()
{
	let component = shallow.shallow(React.createElement(recordlist.DisplayRecord, null));
	component.setState({error:true});
	expect(component.find('p').length).toBe(1);
}
);

test('DisplayRecord (no error)',function()
{
	let component = shallow.shallow(React.createElement(recordlist.DisplayRecord, null));
	expect(component.find('div').length).toBe(1);
	expect(component.find('DisplayTable').length).toBe(1);
	expect(component.find('InputForms').length).toBe(1);
}
);

test('displaytable (empty list)',function()
{
	let component = shallow.shallow(React.createElement(recordlist.DisplayTable, { record: null, obj: null }));
	expect(component.type()).toEqual(null);
}
);

test('snapshot DisplayRecord (no error, no state)',function()
{
  var component = renderer.create(React.createElement(recordlist.DisplayRecord, null));
  var tree = component.toJSON();
  expect(tree).toMatchSnapshot();
}
);