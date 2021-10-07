using System;
using System.Collections.Generic;
using System.Text;

namespace MISP_JsonToDatasets
{
    public class MISP_json_Format
    {
        public Response[] response { get; set; }
    }

    public class Response
    {
        public Event Event { get; set; }
    }

    public class Event
    {
        public string id { get; set; }
        public string orgc_id { get; set; }
        public string org_id { get; set; }
        public string date { get; set; }
        public string threat_level_id { get; set; }
        public string info { get; set; }
        public bool published { get; set; }
        public string uuid { get; set; }
        public string attribute_count { get; set; }
        public string analysis { get; set; }
        public string timestamp { get; set; }
        public string distribution { get; set; }
        public bool proposal_email_lock { get; set; }
        public bool locked { get; set; }
        public string publish_timestamp { get; set; }
        public string sharing_group_id { get; set; }
        public bool disable_correlation { get; set; }
        public string extends_uuid { get; set; }
        public Org Org { get; set; }
        public Orgc Orgc { get; set; }
        public Attribute[] Attribute { get; set; }
        public object[] ShadowAttribute { get; set; }
        public Relatedevent[] RelatedEvent { get; set; }
        public object[] Galaxy { get; set; }
        public Object[] Object { get; set; }
        public object[] EventReport { get; set; }
        public Tag[] Tag { get; set; }
    }

    public class Org
    {
        public string id { get; set; }
        public string name { get; set; }
        public string uuid { get; set; }
        public bool local { get; set; }
    }

    public class Orgc
    {
        public string id { get; set; }
        public string name { get; set; }
        public string uuid { get; set; }
        public bool local { get; set; }
    }

    public class Attribute
    {
        public string id { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public bool to_ids { get; set; }
        public string uuid { get; set; }
        public string event_id { get; set; }
        public string distribution { get; set; }
        public string timestamp { get; set; }
        public string comment { get; set; }
        public string sharing_group_id { get; set; }
        public bool deleted { get; set; }
        public bool disable_correlation { get; set; }
        public string object_id { get; set; }
        public object object_relation { get; set; }
        public object first_seen { get; set; }
        public object last_seen { get; set; }
        public string value { get; set; }
        public object[] Galaxy { get; set; }
        public object[] ShadowAttribute { get; set; }
        public string data { get; set; }
    }

    public class Relatedevent
    {
        public Event1 Event { get; set; }
    }

    public class Event1
    {
        public string id { get; set; }
        public string date { get; set; }
        public string threat_level_id { get; set; }
        public string info { get; set; }
        public bool published { get; set; }
        public string uuid { get; set; }
        public string analysis { get; set; }
        public string timestamp { get; set; }
        public string distribution { get; set; }
        public string org_id { get; set; }
        public string orgc_id { get; set; }
        public Org1 Org { get; set; }
        public Orgc1 Orgc { get; set; }
    }

    public class Org1
    {
        public string id { get; set; }
        public string name { get; set; }
        public string uuid { get; set; }
    }

    public class Orgc1
    {
        public string id { get; set; }
        public string name { get; set; }
        public string uuid { get; set; }
    }

    public class Object
    {
        public string id { get; set; }
        public string name { get; set; }
        public string metacategory { get; set; }
        public string description { get; set; }
        public string template_uuid { get; set; }
        public string template_version { get; set; }
        public string event_id { get; set; }
        public string uuid { get; set; }
        public string timestamp { get; set; }
        public string distribution { get; set; }
        public string sharing_group_id { get; set; }
        public string comment { get; set; }
        public bool deleted { get; set; }
        public object first_seen { get; set; }
        public object last_seen { get; set; }
        public Objectreference[] ObjectReference { get; set; }
        public Attribute1[] Attribute { get; set; }
    }

    public class Objectreference
    {
        public string id { get; set; }
        public string uuid { get; set; }
        public string timestamp { get; set; }
        public string object_id { get; set; }
        public string event_id { get; set; }
        public string source_uuid { get; set; }
        public string referenced_uuid { get; set; }
        public string referenced_id { get; set; }
        public string referenced_type { get; set; }
        public string relationship_type { get; set; }
        public string comment { get; set; }
        public bool deleted { get; set; }
        public Object1 Object { get; set; }
    }

    public class Object1
    {
        public string distribution { get; set; }
        public string sharing_group_id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string metacategory { get; set; }
    }

    public class Attribute1
    {
        public string id { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public bool to_ids { get; set; }
        public string uuid { get; set; }
        public string event_id { get; set; }
        public string distribution { get; set; }
        public string timestamp { get; set; }
        public string comment { get; set; }
        public string sharing_group_id { get; set; }
        public bool deleted { get; set; }
        public bool disable_correlation { get; set; }
        public string object_id { get; set; }
        public string object_relation { get; set; }
        public object first_seen { get; set; }
        public object last_seen { get; set; }
        public object value { get; set; }
        public object[] Galaxy { get; set; }
        public object[] ShadowAttribute { get; set; }
    }

    public class Tag
    {
        public string id { get; set; }
        public string name { get; set; }
        public string colour { get; set; }
        public bool exportable { get; set; }
        public string user_id { get; set; }
        public bool hide_tag { get; set; }
        public object numerical_value { get; set; }
        public bool is_galaxy { get; set; }
        public bool is_custom_galaxy { get; set; }
        public int local { get; set; }
    }

}
