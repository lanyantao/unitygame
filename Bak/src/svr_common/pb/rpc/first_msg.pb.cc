// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: first_msg.proto

#define INTERNAL_SUPPRESS_PROTOBUF_FIELD_DEPRECATION
#include "first_msg.pb.h"

#include <algorithm>

#include <google/protobuf/stubs/common.h>
#include <google/protobuf/stubs/port.h>
#include <google/protobuf/stubs/once.h>
#include <google/protobuf/io/coded_stream.h>
#include <google/protobuf/wire_format_lite_inl.h>
#include <google/protobuf/descriptor.h>
#include <google/protobuf/generated_message_reflection.h>
#include <google/protobuf/reflection_ops.h>
#include <google/protobuf/wire_format.h>
// @@protoc_insertion_point(includes)

namespace rpc {
class FirstMsgDefaultTypeInternal : public ::google::protobuf::internal::ExplicitlyConstructed<FirstMsg> {
} _FirstMsg_default_instance_;

namespace protobuf_first_5fmsg_2eproto {


namespace {

::google::protobuf::Metadata file_level_metadata[1];

}  // namespace

const ::google::protobuf::uint32 TableStruct::offsets[] = {
  GOOGLE_PROTOBUF_GENERATED_MESSAGE_FIELD_OFFSET(FirstMsg, _has_bits_),
  GOOGLE_PROTOBUF_GENERATED_MESSAGE_FIELD_OFFSET(FirstMsg, _internal_metadata_),
  ~0u,  // no _extensions_
  ~0u,  // no _oneof_case_
  GOOGLE_PROTOBUF_GENERATED_MESSAGE_FIELD_OFFSET(FirstMsg, version_),
  GOOGLE_PROTOBUF_GENERATED_MESSAGE_FIELD_OFFSET(FirstMsg, time_),
  GOOGLE_PROTOBUF_GENERATED_MESSAGE_FIELD_OFFSET(FirstMsg, token_),
  1,
  2,
  0,
};

static const ::google::protobuf::internal::MigrationSchema schemas[] = {
  { 0, 7, sizeof(FirstMsg)},
};

static ::google::protobuf::Message const * const file_default_instances[] = {
  reinterpret_cast<const ::google::protobuf::Message*>(&_FirstMsg_default_instance_),
};

namespace {

void protobuf_AssignDescriptors() {
  AddDescriptors();
  ::google::protobuf::MessageFactory* factory = NULL;
  AssignDescriptors(
      "first_msg.proto", schemas, file_default_instances, TableStruct::offsets, factory,
      file_level_metadata, NULL, NULL);
}

void protobuf_AssignDescriptorsOnce() {
  static GOOGLE_PROTOBUF_DECLARE_ONCE(once);
  ::google::protobuf::GoogleOnceInit(&once, &protobuf_AssignDescriptors);
}

void protobuf_RegisterTypes(const ::std::string&) GOOGLE_ATTRIBUTE_COLD;
void protobuf_RegisterTypes(const ::std::string&) {
  protobuf_AssignDescriptorsOnce();
  ::google::protobuf::internal::RegisterAllTypes(file_level_metadata, 1);
}

}  // namespace

void TableStruct::Shutdown() {
  _FirstMsg_default_instance_.Shutdown();
  delete file_level_metadata[0].reflection;
}

void TableStruct::InitDefaultsImpl() {
  GOOGLE_PROTOBUF_VERIFY_VERSION;

  ::google::protobuf::internal::InitProtobufDefaults();
  _FirstMsg_default_instance_.DefaultConstruct();
}

void InitDefaults() {
  static GOOGLE_PROTOBUF_DECLARE_ONCE(once);
  ::google::protobuf::GoogleOnceInit(&once, &TableStruct::InitDefaultsImpl);
}
void AddDescriptorsImpl() {
  InitDefaults();
  static const char descriptor[] = {
      "\n\017first_msg.proto\022\003rpc\"8\n\010FirstMsg\022\017\n\007ve"
      "rsion\030\001 \001(\r\022\014\n\004time\030\002 \001(\r\022\r\n\005token\030\003 \001(\014"
  };
  ::google::protobuf::DescriptorPool::InternalAddGeneratedFile(
      descriptor, 80);
  ::google::protobuf::MessageFactory::InternalRegisterGeneratedFile(
    "first_msg.proto", &protobuf_RegisterTypes);
  ::google::protobuf::internal::OnShutdown(&TableStruct::Shutdown);
}

void AddDescriptors() {
  static GOOGLE_PROTOBUF_DECLARE_ONCE(once);
  ::google::protobuf::GoogleOnceInit(&once, &AddDescriptorsImpl);
}
// Force AddDescriptors() to be called at static initialization time.
struct StaticDescriptorInitializer {
  StaticDescriptorInitializer() {
    AddDescriptors();
  }
} static_descriptor_initializer;

}  // namespace protobuf_first_5fmsg_2eproto


// ===================================================================

#if !defined(_MSC_VER) || _MSC_VER >= 1900
const int FirstMsg::kVersionFieldNumber;
const int FirstMsg::kTimeFieldNumber;
const int FirstMsg::kTokenFieldNumber;
#endif  // !defined(_MSC_VER) || _MSC_VER >= 1900

FirstMsg::FirstMsg()
  : ::google::protobuf::Message(), _internal_metadata_(NULL) {
  if (GOOGLE_PREDICT_TRUE(this != internal_default_instance())) {
    protobuf_first_5fmsg_2eproto::InitDefaults();
  }
  SharedCtor();
  // @@protoc_insertion_point(constructor:rpc.FirstMsg)
}
FirstMsg::FirstMsg(const FirstMsg& from)
  : ::google::protobuf::Message(),
      _internal_metadata_(NULL),
      _has_bits_(from._has_bits_),
      _cached_size_(0) {
  _internal_metadata_.MergeFrom(from._internal_metadata_);
  token_.UnsafeSetDefault(&::google::protobuf::internal::GetEmptyStringAlreadyInited());
  if (from.has_token()) {
    token_.AssignWithDefault(&::google::protobuf::internal::GetEmptyStringAlreadyInited(), from.token_);
  }
  ::memcpy(&version_, &from.version_,
    reinterpret_cast<char*>(&time_) -
    reinterpret_cast<char*>(&version_) + sizeof(time_));
  // @@protoc_insertion_point(copy_constructor:rpc.FirstMsg)
}

void FirstMsg::SharedCtor() {
  _cached_size_ = 0;
  token_.UnsafeSetDefault(&::google::protobuf::internal::GetEmptyStringAlreadyInited());
  ::memset(&version_, 0, reinterpret_cast<char*>(&time_) -
    reinterpret_cast<char*>(&version_) + sizeof(time_));
}

FirstMsg::~FirstMsg() {
  // @@protoc_insertion_point(destructor:rpc.FirstMsg)
  SharedDtor();
}

void FirstMsg::SharedDtor() {
  token_.DestroyNoArena(&::google::protobuf::internal::GetEmptyStringAlreadyInited());
}

void FirstMsg::SetCachedSize(int size) const {
  GOOGLE_SAFE_CONCURRENT_WRITES_BEGIN();
  _cached_size_ = size;
  GOOGLE_SAFE_CONCURRENT_WRITES_END();
}
const ::google::protobuf::Descriptor* FirstMsg::descriptor() {
  protobuf_first_5fmsg_2eproto::protobuf_AssignDescriptorsOnce();
  return protobuf_first_5fmsg_2eproto::file_level_metadata[0].descriptor;
}

const FirstMsg& FirstMsg::default_instance() {
  protobuf_first_5fmsg_2eproto::InitDefaults();
  return *internal_default_instance();
}

FirstMsg* FirstMsg::New(::google::protobuf::Arena* arena) const {
  FirstMsg* n = new FirstMsg;
  if (arena != NULL) {
    arena->Own(n);
  }
  return n;
}

void FirstMsg::Clear() {
// @@protoc_insertion_point(message_clear_start:rpc.FirstMsg)
  if (has_token()) {
    GOOGLE_DCHECK(!token_.IsDefault(&::google::protobuf::internal::GetEmptyStringAlreadyInited()));
    (*token_.UnsafeRawStringPointer())->clear();
  }
  if (_has_bits_[0 / 32] & 6u) {
    ::memset(&version_, 0, reinterpret_cast<char*>(&time_) -
      reinterpret_cast<char*>(&version_) + sizeof(time_));
  }
  _has_bits_.Clear();
  _internal_metadata_.Clear();
}

bool FirstMsg::MergePartialFromCodedStream(
    ::google::protobuf::io::CodedInputStream* input) {
#define DO_(EXPRESSION) if (!GOOGLE_PREDICT_TRUE(EXPRESSION)) goto failure
  ::google::protobuf::uint32 tag;
  // @@protoc_insertion_point(parse_start:rpc.FirstMsg)
  for (;;) {
    ::std::pair< ::google::protobuf::uint32, bool> p = input->ReadTagWithCutoffNoLastTag(127u);
    tag = p.first;
    if (!p.second) goto handle_unusual;
    switch (::google::protobuf::internal::WireFormatLite::GetTagFieldNumber(tag)) {
      // optional uint32 version = 1;
      case 1: {
        if (static_cast<::google::protobuf::uint8>(tag) ==
            static_cast<::google::protobuf::uint8>(8u)) {
          set_has_version();
          DO_((::google::protobuf::internal::WireFormatLite::ReadPrimitive<
                   ::google::protobuf::uint32, ::google::protobuf::internal::WireFormatLite::TYPE_UINT32>(
                 input, &version_)));
        } else {
          goto handle_unusual;
        }
        break;
      }

      // optional uint32 time = 2;
      case 2: {
        if (static_cast<::google::protobuf::uint8>(tag) ==
            static_cast<::google::protobuf::uint8>(16u)) {
          set_has_time();
          DO_((::google::protobuf::internal::WireFormatLite::ReadPrimitive<
                   ::google::protobuf::uint32, ::google::protobuf::internal::WireFormatLite::TYPE_UINT32>(
                 input, &time_)));
        } else {
          goto handle_unusual;
        }
        break;
      }

      // optional bytes token = 3;
      case 3: {
        if (static_cast<::google::protobuf::uint8>(tag) ==
            static_cast<::google::protobuf::uint8>(26u)) {
          DO_(::google::protobuf::internal::WireFormatLite::ReadBytes(
                input, this->mutable_token()));
        } else {
          goto handle_unusual;
        }
        break;
      }

      default: {
      handle_unusual:
        if (tag == 0 ||
            ::google::protobuf::internal::WireFormatLite::GetTagWireType(tag) ==
            ::google::protobuf::internal::WireFormatLite::WIRETYPE_END_GROUP) {
          goto success;
        }
        DO_(::google::protobuf::internal::WireFormat::SkipField(
              input, tag, mutable_unknown_fields()));
        break;
      }
    }
  }
success:
  // @@protoc_insertion_point(parse_success:rpc.FirstMsg)
  return true;
failure:
  // @@protoc_insertion_point(parse_failure:rpc.FirstMsg)
  return false;
#undef DO_
}

void FirstMsg::SerializeWithCachedSizes(
    ::google::protobuf::io::CodedOutputStream* output) const {
  // @@protoc_insertion_point(serialize_start:rpc.FirstMsg)
  // optional uint32 version = 1;
  if (has_version()) {
    ::google::protobuf::internal::WireFormatLite::WriteUInt32(1, this->version(), output);
  }

  // optional uint32 time = 2;
  if (has_time()) {
    ::google::protobuf::internal::WireFormatLite::WriteUInt32(2, this->time(), output);
  }

  // optional bytes token = 3;
  if (has_token()) {
    ::google::protobuf::internal::WireFormatLite::WriteBytesMaybeAliased(
      3, this->token(), output);
  }

  if (_internal_metadata_.have_unknown_fields()) {
    ::google::protobuf::internal::WireFormat::SerializeUnknownFields(
        unknown_fields(), output);
  }
  // @@protoc_insertion_point(serialize_end:rpc.FirstMsg)
}

::google::protobuf::uint8* FirstMsg::InternalSerializeWithCachedSizesToArray(
    bool deterministic, ::google::protobuf::uint8* target) const {
  (void)deterministic;  // Unused
  // @@protoc_insertion_point(serialize_to_array_start:rpc.FirstMsg)
  // optional uint32 version = 1;
  if (has_version()) {
    target = ::google::protobuf::internal::WireFormatLite::WriteUInt32ToArray(1, this->version(), target);
  }

  // optional uint32 time = 2;
  if (has_time()) {
    target = ::google::protobuf::internal::WireFormatLite::WriteUInt32ToArray(2, this->time(), target);
  }

  // optional bytes token = 3;
  if (has_token()) {
    target =
      ::google::protobuf::internal::WireFormatLite::WriteBytesToArray(
        3, this->token(), target);
  }

  if (_internal_metadata_.have_unknown_fields()) {
    target = ::google::protobuf::internal::WireFormat::SerializeUnknownFieldsToArray(
        unknown_fields(), target);
  }
  // @@protoc_insertion_point(serialize_to_array_end:rpc.FirstMsg)
  return target;
}

size_t FirstMsg::ByteSizeLong() const {
// @@protoc_insertion_point(message_byte_size_start:rpc.FirstMsg)
  size_t total_size = 0;

  if (_internal_metadata_.have_unknown_fields()) {
    total_size +=
      ::google::protobuf::internal::WireFormat::ComputeUnknownFieldsSize(
        unknown_fields());
  }
  if (_has_bits_[0 / 32] & 7u) {
    // optional bytes token = 3;
    if (has_token()) {
      total_size += 1 +
        ::google::protobuf::internal::WireFormatLite::BytesSize(
          this->token());
    }

    // optional uint32 version = 1;
    if (has_version()) {
      total_size += 1 +
        ::google::protobuf::internal::WireFormatLite::UInt32Size(
          this->version());
    }

    // optional uint32 time = 2;
    if (has_time()) {
      total_size += 1 +
        ::google::protobuf::internal::WireFormatLite::UInt32Size(
          this->time());
    }

  }
  int cached_size = ::google::protobuf::internal::ToCachedSize(total_size);
  GOOGLE_SAFE_CONCURRENT_WRITES_BEGIN();
  _cached_size_ = cached_size;
  GOOGLE_SAFE_CONCURRENT_WRITES_END();
  return total_size;
}

void FirstMsg::MergeFrom(const ::google::protobuf::Message& from) {
// @@protoc_insertion_point(generalized_merge_from_start:rpc.FirstMsg)
  GOOGLE_DCHECK_NE(&from, this);
  const FirstMsg* source =
      ::google::protobuf::internal::DynamicCastToGenerated<const FirstMsg>(
          &from);
  if (source == NULL) {
  // @@protoc_insertion_point(generalized_merge_from_cast_fail:rpc.FirstMsg)
    ::google::protobuf::internal::ReflectionOps::Merge(from, this);
  } else {
  // @@protoc_insertion_point(generalized_merge_from_cast_success:rpc.FirstMsg)
    MergeFrom(*source);
  }
}

void FirstMsg::MergeFrom(const FirstMsg& from) {
// @@protoc_insertion_point(class_specific_merge_from_start:rpc.FirstMsg)
  GOOGLE_DCHECK_NE(&from, this);
  _internal_metadata_.MergeFrom(from._internal_metadata_);
  if (from._has_bits_[0 / 32] & 7u) {
    if (from.has_token()) {
      set_has_token();
      token_.AssignWithDefault(&::google::protobuf::internal::GetEmptyStringAlreadyInited(), from.token_);
    }
    if (from.has_version()) {
      set_version(from.version());
    }
    if (from.has_time()) {
      set_time(from.time());
    }
  }
}

void FirstMsg::CopyFrom(const ::google::protobuf::Message& from) {
// @@protoc_insertion_point(generalized_copy_from_start:rpc.FirstMsg)
  if (&from == this) return;
  Clear();
  MergeFrom(from);
}

void FirstMsg::CopyFrom(const FirstMsg& from) {
// @@protoc_insertion_point(class_specific_copy_from_start:rpc.FirstMsg)
  if (&from == this) return;
  Clear();
  MergeFrom(from);
}

bool FirstMsg::IsInitialized() const {
  return true;
}

void FirstMsg::Swap(FirstMsg* other) {
  if (other == this) return;
  InternalSwap(other);
}
void FirstMsg::InternalSwap(FirstMsg* other) {
  token_.Swap(&other->token_);
  std::swap(version_, other->version_);
  std::swap(time_, other->time_);
  std::swap(_has_bits_[0], other->_has_bits_[0]);
  _internal_metadata_.Swap(&other->_internal_metadata_);
  std::swap(_cached_size_, other->_cached_size_);
}

::google::protobuf::Metadata FirstMsg::GetMetadata() const {
  protobuf_first_5fmsg_2eproto::protobuf_AssignDescriptorsOnce();
  return protobuf_first_5fmsg_2eproto::file_level_metadata[0];
}

#if PROTOBUF_INLINE_NOT_IN_HEADERS
// FirstMsg

// optional uint32 version = 1;
bool FirstMsg::has_version() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
void FirstMsg::set_has_version() {
  _has_bits_[0] |= 0x00000002u;
}
void FirstMsg::clear_has_version() {
  _has_bits_[0] &= ~0x00000002u;
}
void FirstMsg::clear_version() {
  version_ = 0u;
  clear_has_version();
}
::google::protobuf::uint32 FirstMsg::version() const {
  // @@protoc_insertion_point(field_get:rpc.FirstMsg.version)
  return version_;
}
void FirstMsg::set_version(::google::protobuf::uint32 value) {
  set_has_version();
  version_ = value;
  // @@protoc_insertion_point(field_set:rpc.FirstMsg.version)
}

// optional uint32 time = 2;
bool FirstMsg::has_time() const {
  return (_has_bits_[0] & 0x00000004u) != 0;
}
void FirstMsg::set_has_time() {
  _has_bits_[0] |= 0x00000004u;
}
void FirstMsg::clear_has_time() {
  _has_bits_[0] &= ~0x00000004u;
}
void FirstMsg::clear_time() {
  time_ = 0u;
  clear_has_time();
}
::google::protobuf::uint32 FirstMsg::time() const {
  // @@protoc_insertion_point(field_get:rpc.FirstMsg.time)
  return time_;
}
void FirstMsg::set_time(::google::protobuf::uint32 value) {
  set_has_time();
  time_ = value;
  // @@protoc_insertion_point(field_set:rpc.FirstMsg.time)
}

// optional bytes token = 3;
bool FirstMsg::has_token() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
void FirstMsg::set_has_token() {
  _has_bits_[0] |= 0x00000001u;
}
void FirstMsg::clear_has_token() {
  _has_bits_[0] &= ~0x00000001u;
}
void FirstMsg::clear_token() {
  token_.ClearToEmptyNoArena(&::google::protobuf::internal::GetEmptyStringAlreadyInited());
  clear_has_token();
}
const ::std::string& FirstMsg::token() const {
  // @@protoc_insertion_point(field_get:rpc.FirstMsg.token)
  return token_.GetNoArena();
}
void FirstMsg::set_token(const ::std::string& value) {
  set_has_token();
  token_.SetNoArena(&::google::protobuf::internal::GetEmptyStringAlreadyInited(), value);
  // @@protoc_insertion_point(field_set:rpc.FirstMsg.token)
}
#if LANG_CXX11
void FirstMsg::set_token(::std::string&& value) {
  set_has_token();
  token_.SetNoArena(
    &::google::protobuf::internal::GetEmptyStringAlreadyInited(), ::std::move(value));
  // @@protoc_insertion_point(field_set_rvalue:rpc.FirstMsg.token)
}
#endif
void FirstMsg::set_token(const char* value) {
  set_has_token();
  token_.SetNoArena(&::google::protobuf::internal::GetEmptyStringAlreadyInited(), ::std::string(value));
  // @@protoc_insertion_point(field_set_char:rpc.FirstMsg.token)
}
void FirstMsg::set_token(const void* value, size_t size) {
  set_has_token();
  token_.SetNoArena(&::google::protobuf::internal::GetEmptyStringAlreadyInited(),
      ::std::string(reinterpret_cast<const char*>(value), size));
  // @@protoc_insertion_point(field_set_pointer:rpc.FirstMsg.token)
}
::std::string* FirstMsg::mutable_token() {
  set_has_token();
  // @@protoc_insertion_point(field_mutable:rpc.FirstMsg.token)
  return token_.MutableNoArena(&::google::protobuf::internal::GetEmptyStringAlreadyInited());
}
::std::string* FirstMsg::release_token() {
  // @@protoc_insertion_point(field_release:rpc.FirstMsg.token)
  clear_has_token();
  return token_.ReleaseNoArena(&::google::protobuf::internal::GetEmptyStringAlreadyInited());
}
void FirstMsg::set_allocated_token(::std::string* token) {
  if (token != NULL) {
    set_has_token();
  } else {
    clear_has_token();
  }
  token_.SetAllocatedNoArena(&::google::protobuf::internal::GetEmptyStringAlreadyInited(), token);
  // @@protoc_insertion_point(field_set_allocated:rpc.FirstMsg.token)
}

#endif  // PROTOBUF_INLINE_NOT_IN_HEADERS

// @@protoc_insertion_point(namespace_scope)

}  // namespace rpc

// @@protoc_insertion_point(global_scope)